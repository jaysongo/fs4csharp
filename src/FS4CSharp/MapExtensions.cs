using System;

namespace FS4CSharp
{
    public static class MapExtensions
    {
        public static TOutput Map<TInput, TOutput>(this TInput input, Func<TInput, TOutput> map) => map(input);

        public static TInput Map<TInput>(this TInput input, Action map)
        {
            map();
            return input;
        }

        public static void MapFinal<TInput>(this TInput input, Action<TInput> map) => map(input);
    }
}
