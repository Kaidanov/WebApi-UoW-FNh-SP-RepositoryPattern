using FluentNHibernate.Automapping;
using System;
using UnitOfWork.Domain.Entities;

namespace UnitOfWork.Data.Helpers
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterface(typeof(IEntity).FullName) != null;
        }
    }
}
