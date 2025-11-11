namespace HRAdministrationApi;


    public static class FactoryPattern<TK, T> where T : class, TK, new()
    {
        public static TK GetInstance()
        {
            TK Obj = new T();
            return Obj;
        }
    }