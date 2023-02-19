﻿using Microsoft.Extensions.Configuration;

namespace ComeTogether.Settings
{
    public abstract class Settings
    {
        /// <summary>
        /// Method that loads environment variables from configuration(appsettings.json) by using <paramref name="key"/> to instance of <typeparamref name="T"/> and than returns.
        /// </summary>
        public static T? Load<T>(string key, IConfiguration configuration = null)
        {
            var instance = (T?)Activator.CreateInstance(typeof(T));
            SettingsFactory.Create(configuration)
                .GetSection(key)
                .Bind(instance, (x) => { x.BindNonPublicProperties = true; });

            return instance;
        }
    }
}
