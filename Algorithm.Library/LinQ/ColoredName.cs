namespace Algorithm.Library.LinQ
{
    public class ColoredName
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public ColoredName()
        {

        }

        public ColoredName(string name, string color)
        {
            Name = name;
            Color = color;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            ColoredName otherColoredName = obj as ColoredName;

            if (otherColoredName == null) 
                return false;

            return (Name == otherColoredName.Name)
                && (Color == otherColoredName.Color);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (Name.GetHashCode() * 11) + (Color.GetHashCode() * 13);
        }
    }
}
