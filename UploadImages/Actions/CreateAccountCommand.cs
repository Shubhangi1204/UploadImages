using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.ApplicationModels;

namespace UploadImages.Actions
{
    public class CreateAccountCommand : IRequest<ApplicationAccount>
    {
        public string Name { get; }
        public CreateAccountCommand(string name)
        {
            Name = name; 
        }
    }
}
