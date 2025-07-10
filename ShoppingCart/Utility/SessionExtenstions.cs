

using System.Text.Json;




namespace ShoppingCart.Utility
{
    public static class SessionExtenstions
    {
        public static void SetObject(this ISession session, string key, Object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        //remove ? after T
        public static T? GetObject<T>(this ISession session, string key)
        {
           var value= session.GetString(key);
            return value == null ? default :
                JsonSerializer.Deserialize<T>(value);

        }
    }
}
