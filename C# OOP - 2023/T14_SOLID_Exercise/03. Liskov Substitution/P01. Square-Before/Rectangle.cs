namespace P01._Square_Before
{
    public class Rectangle : Square
    {
        public override double Area => this.Width * this.Height;

        public override double Width
        {
            get { return base.Width; }
            set
            {
                base.Width = value;
            }
        }

        public virtual double Height { get; set; }
    }
}
