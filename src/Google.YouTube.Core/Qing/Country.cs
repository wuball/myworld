using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Abp.Auditing;

namespace Google.YouTube.Qing
{
    [Table("Countries")]
    [Audited]
    public class Country : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(CountryConsts.MaxNameLength, MinimumLength = CountryConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(CountryConsts.MaxRegionLength, MinimumLength = CountryConsts.MinRegionLength)]
        public virtual string Region { get; set; }

        [StringLength(CountryConsts.MaxSubRegionLength, MinimumLength = CountryConsts.MinSubRegionLength)]
        public virtual string SubRegion { get; set; }

        public virtual bool English { get; set; }

        public virtual double Latitude { get; set; }

        public virtual double Longitude { get; set; }

        public virtual int Area { get; set; }

        public virtual string CallingCodes { get; set; }

        public virtual bool Landlocked { get; set; }

        public virtual string Capital { get; set; }

        public virtual string Flag { get; set; }

        public virtual bool Independent { get; set; }

        public virtual string Organization { get; set; }

        public virtual string Visa { get; set; }

        public virtual string Extradition { get; set; }

        public virtual string Repatriate { get; set; }

        public virtual string WorkingVisa { get; set; }

        public virtual bool ProAmerican { get; set; }

        public virtual bool Birthright { get; set; }

    }
}