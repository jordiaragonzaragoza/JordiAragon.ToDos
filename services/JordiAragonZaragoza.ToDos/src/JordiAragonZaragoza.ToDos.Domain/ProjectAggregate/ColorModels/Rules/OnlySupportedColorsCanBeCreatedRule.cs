namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.ColorModels.Rules
{
    using System.Collections.Generic;
    using System.Linq;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class OnlySupportedColorsCanBeCreatedRule : IBusinessRule
    {
        private readonly Color color;
        private readonly IEnumerable<Color> supportedColors;

        public OnlySupportedColorsCanBeCreatedRule(Color color, IEnumerable<Color> supportedColors)
        {
            this.color = Guard.Against.Null(color, nameof(color));
            this.supportedColors = Guard.Against.NullOrEmpty(supportedColors, nameof(supportedColors));
        }

        public string Message => $"Only supported colors can be created:\n{string.Join(",\n", this.supportedColors.Select(c => c.ToString()))}";

        public bool IsBroken() => !this.supportedColors.Contains(this.color);
    }
}