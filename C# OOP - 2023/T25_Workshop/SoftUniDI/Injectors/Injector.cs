using System;
using System.Reflection;
using SoftUniDI.Attributes;
using SoftUniDI.Modules.Contracts;

namespace SoftUniDI.Injectors
{
    public class Injector
    {
        private IModule module;
        public Injector(IModule module)
        {
            this.module = module;
        }


        private TClass CreateConstructorInjection<TClass>()
        {
            var desireClass = typeof(TClass);

            if (desireClass == null) return default(TClass);
            var constructors = desireClass.GetConstructors();

            foreach (var constructor in constructors)
            {
                if (CheckForConstructorInjection<TClass>()) continue;

                var inject = (Inject)constructor
                    .GetCustomAttributes(typeof(Inject), true)
                    .FirstOrDefault();

                var parameterTypes = constructor.GetParameters();
                var constructorParams = new object[parameterTypes.Length];

                var i = 0;

                foreach (var parameterType in parameterTypes)
                {
                    var named = parameterType.GetCustomAttribute(typeof(Named));
                    Type dependency = null;

                    if (named == null)
                    {
                        dependency = this.module.GetMapping(parameterType.ParameterType, inject);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(parameterType.ParameterType, named);
                    }

                    if (parameterType.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstace(dependency);
                        if (instance != null)
                        {
                            constructorParams[i++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependency);
                            constructorParams[i++] = instance;
                            this.module.SetInstance(parameterType.ParameterType, instance);
                        }
                    }
                }

                return (TClass)Activator.CreateInstance(desireClass, constructorParams);
            }

            return default(TClass);
        }

        private TClass CreateFieldsInjection<TClass>()
        {
            var desireClass = typeof(TClass);
            var desireClassInstance = this.module.GetInstace(desireClass);

            if (desireClassInstance == null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                this.module.SetInstance(desireClass, desireClassInstance);
            }

            var fields = desireClass.GetFields((BindingFlags)62);

            foreach (var field in fields)
            {
                if (field.GetCustomAttributes(typeof(Inject), true).Any())
                {
                    var injection = (Inject)field
                        .GetCustomAttributes(typeof(Inject), true)
                        .FirstOrDefault();
                    Type dependency = null;

                    var named = field.GetCustomAttributes(typeof(Inject), true).Any();
                    var type = field.FieldType;

                    if (named == null)
                    {
                        dependency = this.module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(type, named);
                    }

                    if (type.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstace(dependency);
                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            this.module.SetInstance(dependency, instance);
                        }

                        field.SetValue(desireClassInstance, instance);
                    }
                }

            }

            return (TClass)desireClassInstance;
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags)62)
                .Any(field => field.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(constructor => constructor.GetCustomAttributes(typeof(Inject), true).Any());
        }

        public TClass Inject<TClass>()
        {
            var hasConstructorAtribute = this.CheckForConstructorInjection<TClass>();
            var hasFieldAtribute = this.CheckForFieldInjection<TClass>();

            if (hasConstructorAtribute && hasFieldAtribute)
            {
                throw new ArgumentException("There must be only field or constructor annotated with Inject attribute");
            }

            if (hasConstructorAtribute)
            {
                this.CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAtribute)
            {
                this.CreateFieldsInjection<TClass>();
            }

            return default(TClass);
        }
    }
}