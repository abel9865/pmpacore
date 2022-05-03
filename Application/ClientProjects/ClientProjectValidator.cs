using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.ClientProjects
{
    public class ClientProjectValidator : AbstractValidator<ClientProject>
    {
        public ClientProjectValidator()
        {
            RuleFor(x => x.ProjectTitle).NotEmpty();
            RuleFor(x => x.ClientId).NotEmpty();
            RuleFor(x => x.ProjectDescription).NotEmpty();
            RuleFor(x => x.CreatedDate).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
            RuleFor(x => x.LastUpdatedDate).NotEmpty();
            RuleFor(x => x.LastUpdatedBy).NotEmpty();
            
        }
    }
}