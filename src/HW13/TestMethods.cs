namespace HW13
{
    class 
        TestMethods
    {
        public string Method(string input)
        {
            input += input;
            return input;
        }

        public virtual string VirtualMethod(string input)
        {
            input += input;
            return input;
        }

        public static string StaticMethod(string input)
        {
            input += input;
            return input;
        }

        public string GenericMethod<T>(T input)
        {
            return input.ToString() + input;
        }

        public string DynamicMethod(dynamic input)
        {
            input += input.ToString();
            return input;
        }

        public string ReflectionMethod(string input)
        {
            input += input;
            return input;
        }
    }
}