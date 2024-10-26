namespace JordiAragonZaragoza.ToDos.Application.Features.Analytics.Queries
{
    using System;
    using Ardalis.Specification;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Entities;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Analytics.Queries;

    public abstract class BaseKeyPerformanceIndicatorSpec<TEntity, TId> : Specification<TEntity, KeyPerformanceIndicatorOutputDto>
        where TEntity : BaseAuditableEntity<TId>
    {
        protected BaseKeyPerformanceIndicatorSpec(
            IDateTime dateTimeService,
            DateTime? sourcePeriodStartDate = null,
            DateTime? sourcePeriodEndDate = null,
            DateTime? comparisonPeriodStartDate = null,
            DateTime? comparisonPeriodEndDate = null)
        {
        }
    }
}