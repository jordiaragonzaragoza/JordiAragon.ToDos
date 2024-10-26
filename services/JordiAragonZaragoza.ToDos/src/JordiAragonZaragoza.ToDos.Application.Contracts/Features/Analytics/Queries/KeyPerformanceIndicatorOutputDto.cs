namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Analytics.Queries
{
    using System;

    public record class KeyPerformanceIndicatorOutputDto
    {
        public decimal Value { get; init; }

        public decimal? ValueRate { get; init; }

        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }

        public decimal? Change { get; init; }

        public decimal? ChangeRate { get; init; }

        public DateTime? ComparisonStartDate { get; init; }

        public DateTime? ComparisonEndDate { get; init; }
    }
}