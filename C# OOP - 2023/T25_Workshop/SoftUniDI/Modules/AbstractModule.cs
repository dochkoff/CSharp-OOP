using System;
using SoftUniDI.Attributes;
using SoftUniDI.Modules.Contracts;

namespace SoftUniDI.Modules
{
    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> implementaions;
        private IDictionary<Type, object> instances;

        public AbstractModule()
        {
            this.implementaions = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        public Type GetMapping(Type currentInterface, object attribute)
        {
            var currentImplementation = this.implementaions[currentInterface];

            Type type = null;

            if (attribute is Inject)
            {
                if (currentImplementation.Count == 1)
                {
                    type = currentImplementation.Values.First();
                }
                else
                {
                    throw new ArgumentException($"No available mapping for class: {currentInterface.FullName}");
                }
            }
            else if (attribute is Named)
            {
                Named named = attribute as Named;

                string dependencyName = named.Name;
                type = currentImplementation[dependencyName];
            }

            return type;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
            {
                this.instances.Add(implementation, instance);
            }
        }

        public object GetInstace(Type implementation)
        {
            this.instances.TryGetValue(implementation, out object value);
            return value;
        }


        protected void CreateMapping<TInter, TImpl>()
        {
            if (this.implementaions.ContainsKey(typeof(TInter)))
            {
                this.implementaions[typeof(TInter)] = new Dictionary<string, Type>();
            }

            this.implementaions[typeof(TInter)].Add(typeof(TImpl).Name, typeof(TImpl));
        }
    }
}

