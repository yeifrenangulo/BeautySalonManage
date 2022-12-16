﻿namespace BeautySalonManage.Domain.Common
{
    public abstract class BaseEntity
    {
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
