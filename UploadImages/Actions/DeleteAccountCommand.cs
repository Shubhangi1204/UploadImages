using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImages.Actions
{
    public class DeleteAccountCommand : IRequest<bool>
    {
        public int Id;

        public DeleteAccountCommand(int id)
        {
            Id = id;
        }
    }
}
