using System;
using FluentValidation.Results;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsCanceled { get; set; }
        public ValidationResult ValidationResult { get; protected set; }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}