public static class ServiceLocator
{
    static Dictionary<Type, object> servicesDictionary = new Dictionary<Type, object>();

    public static void Register<T>(T service)
    {
        servicesDictionary[typeof(T)] = service;
    }

    public static T GetService<T>()
    {
        T instance = default(T);

        if (servicesDictionary.ContainsKey(typeof(T)) == true)
        {
            instance = (T)servicesDictionary[typeof(T)];
        }

        return instance;
    }
}