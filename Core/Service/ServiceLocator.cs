using System;
using System.Collections.Generic;

namespace Core.Service
{
    /// <summary>
    ///     A simple service locator.
    /// </summary>
    public class ServiceLocator
    {
        private readonly Dictionary<Type, object> _services;

        private ServiceLocator()
        {
            _services = new Dictionary<Type, object>();
        }

        /// <summary>
        ///     Gets a singleton instance of the ServiceLocator class.
        /// </summary>
        public static ServiceLocator Default { get; } = new ServiceLocator();

        /// <summary>
        ///     Register a new instance in the container.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="instance"></param>
        public void Register(Type type, object instance)
        {
            if (!_services.ContainsKey(type))
                _services.Add(type, instance);
            else
                throw new ArgumentException($"Type {type.FullName} already registered.");
        }

        /// <summary>
        ///     Try to resolve instance of given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return (T) Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            if (_services.ContainsKey(type))
                return _services[type];

            throw new ArgumentException($"Cannot resolve instance for type {type.FullName}. Call register first.");
        }
    }
}