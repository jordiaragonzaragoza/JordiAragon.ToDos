namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate
{
    using System;
    using JordiAragon.SharedKernel.Domain.Enums;

    public class Priority : SmartEnum<Priority>
    {
        public static readonly Priority None = new(nameof(None), 0);
        public static readonly Priority Low = new(nameof(Low), 1);
        public static readonly Priority Medium = new(nameof(Medium), 2);
        public static readonly Priority High = new(nameof(High), 3);
        public static readonly Priority Critical = new(nameof(Critical), 4);

        protected Priority(string name, int value)
            : base(name, value)
        {
        }
    }
}