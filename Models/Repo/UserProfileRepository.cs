﻿using Amos.VTUCORE3._1.Models.DTO;
using Amos.VTUCORE3._1.Models.Repo.Infrastructure;
using Amos.VTUCORE3._1.Models.Repo.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.Repo
{
    public class UserProfileRepository : BaseRepository<UserProfile>
    {
        public UserProfileRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
