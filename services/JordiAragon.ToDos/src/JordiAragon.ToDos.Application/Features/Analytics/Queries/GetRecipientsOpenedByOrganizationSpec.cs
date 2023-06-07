/*namespace JordiAragon.ToDos.Application.Features.Analytics.Queries
{
    using System;
    using System.Linq;
    using Ardalis.Specification;
    using JordiAragon.ToDos.Application.Contracts.Dtos.Analytics.Output;
    using JordiAragon.ToDos.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.Entities;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class GetRecipientsOpenedByOrganizationSpec : BaseKeyPerformanceIndicatorSpec<Organization>
    {
        public GetRecipientsOpenedByOrganizationSpec(
            Guid organizationId,
            IDateTime dateTimeService,
            DateTime? sourcePeriodStartDate = null,
            DateTime? sourcePeriodEndDate = null,
            DateTime? comparisonPeriodStartDate = null,
            DateTime? comparisonPeriodEndDate = null)
            : base(
                  dateTimeService,
                  sourcePeriodStartDate,
                  sourcePeriodEndDate,
                  comparisonPeriodStartDate,
                  comparisonPeriodEndDate)
        {
            sourcePeriodStartDate = sourcePeriodStartDate ?? default(DateTime);
            sourcePeriodEndDate = sourcePeriodEndDate ?? dateTimeService.UtcNow;

            this.Query
                .Where(organization => organization.Id == organizationId)
                .AsNoTracking();

            if (comparisonPeriodStartDate == null || comparisonPeriodEndDate == null)
            {
                this.Query
                .Select(organization => new KeyPerformanceIndicatorOutputDto()
                {
                    Value = organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Count(recipient => recipient.HasOpened
                                                                && recipient.CreationDate >= sourcePeriodStartDate
                                                                && recipient.CreationDate <= sourcePeriodEndDate),

                    ValueRate = (!organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Any(recipient => recipient.CreationDate >= sourcePeriodStartDate
                                                              && recipient.CreationDate <= sourcePeriodEndDate)) ? null :

                    (decimal)(organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Count(recipient => recipient.HasOpened
                                                                && recipient.CreationDate >= sourcePeriodStartDate
                                                                && recipient.CreationDate <= sourcePeriodEndDate) * 100)
                            / organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Count(recipient => recipient.CreationDate >= sourcePeriodStartDate
                                                                && recipient.CreationDate <= sourcePeriodEndDate),

                    StartDate = sourcePeriodStartDate.Value,
                    EndDate = sourcePeriodEndDate.Value,
                });
            }
            else
            {
                this.Query
                .Select(organization => new KeyPerformanceIndicatorOutputDto()
                {
                    Value = organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Count(recipient => recipient.HasOpened
                                                                && recipient.CreationDate >= sourcePeriodStartDate
                                                                && recipient.CreationDate <= sourcePeriodEndDate),

                    ValueRate = (!organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Any(recipient => recipient.CreationDate >= sourcePeriodStartDate
                                                              && recipient.CreationDate <= sourcePeriodEndDate)) ? null :

                    (decimal)(organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Count(recipient => recipient.HasOpened
                                                                && recipient.CreationDate >= sourcePeriodStartDate
                                                                && recipient.CreationDate <= sourcePeriodEndDate) * 100)
                            / organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Count(recipient => recipient.CreationDate >= sourcePeriodStartDate
                                                                && recipient.CreationDate <= sourcePeriodEndDate),

                    StartDate = sourcePeriodStartDate.Value,
                    EndDate = sourcePeriodEndDate.Value,

                    Change = organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Count(recipient => recipient.HasOpened
                                                                && recipient.CreationDate >= sourcePeriodStartDate
                                                                && recipient.CreationDate <= sourcePeriodEndDate)
                                            -
                             organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Count(recipient => recipient.HasOpened
                                                                && recipient.CreationDate >= comparisonPeriodStartDate
                                                                && recipient.CreationDate <= comparisonPeriodEndDate),

                    ChangeRate = (!organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Any(recipient => recipient.HasOpened
                                                                && recipient.CreationDate >= comparisonPeriodStartDate
                                                                && recipient.CreationDate <= comparisonPeriodEndDate)) ? null :
                            ((organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Count(recipient => recipient.HasOpened
                                                                && recipient.CreationDate >= sourcePeriodStartDate
                                                                && recipient.CreationDate <= sourcePeriodEndDate)
                                            -
                             organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Count(recipient => recipient.HasOpened
                                                                && recipient.CreationDate >= comparisonPeriodStartDate
                                                                && recipient.CreationDate <= comparisonPeriodEndDate)) * 100)
                                            /
                            organization.Customers
                                            .SelectMany(customer => customer.Recipients)
                                            .Count(recipient => recipient.HasOpened
                                                                && recipient.CreationDate >= comparisonPeriodStartDate
                                                                && recipient.CreationDate <= comparisonPeriodEndDate),

                    ComparisonStartDate = comparisonPeriodStartDate.Value,
                    ComparisonEndDate = comparisonPeriodEndDate.Value,
                });
            }
        }
    }
}*/