using CAMMS.Strategy.Application.DTO;
using CAMMS.Strategy.Application.Interface;
using CAMMS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using Serilog;
using Microsoft.Data.SqlClient;

namespace CAMMS.Strategy.Application.Query
{
    public class GetAllQUSummeryQueryHandler : IRequestHandler<GetAllQuickUpdateSummeryQuery, List<QuickUpdateSummeryDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllQUSummeryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<List<QuickUpdateSummeryDto>> Handle(GetAllQuickUpdateSummeryQuery request, CancellationToken cancellationToken)
        {
            var quSectionList = new List<QuickUpdateSection>();

            var quUserSectionList = new List<UserQuickUpdateSection>();

            var actionList = new List<Domain.Action>();
            List<QuickUpdateSummeryDto> QUSummeryDtoList = new List<QuickUpdateSummeryDto>();
            //List<UserQuickUpdateSectionDto> quUserSectionDtoList;


            quSectionList = await unitOfWork.GetRepository<Domain.QuickUpdateSection>().GetAllAsync();          

            foreach (var section in quSectionList)
            {
                if (section.UniqueName == "MYRISKS")
                {
                   // SqlParameter[] parameters =
                   //  {
                   //    new SqlParameter("@STAFFID", "69990D31-7176-4A7D-926E-2D3C4AC45EE3"),
                   //     new SqlParameter("@SearchCriteria", null),
                   //       new SqlParameter("@PageIndex", 0),
                   //         new SqlParameter("@PageSize", 50)
                   // };                
                   //var risks = await unitOfWork.GetRepository<Domain.QuickUpdateStrategicRisk>().ExecuteReaderAsync<Domain.QuickUpdateStrategicRisk>("[dbo].GetStrategicRisksForQuickUpdate", parameters);
                          
                }
                else
                {
                    QUSummeryDtoList.Add(
                          new QuickUpdateSummeryDto
                          {
                              QuickUpdateSectionCode = section.UniqueName,
                              QuickUpdateSectionName = section.SectionName,                             
                              Sort = section.Sort
                          }
                           );

                }

            }

            //actionList = await unitOfWork.GetRepository<Domain.Action>().GetAllPagedAsync(request.PageNumber.Value, request.PageSize.Value);
            //actionDtoList = mapper.Map<List<ActionDto>>(actionList);


            return await Task.FromResult(QUSummeryDtoList.OrderByDescending(o => o.Sort).ToList());
        }

        private async Task<List<Domain.UserQuickUpdateSection>> GetUserQuickUpdateSectionList(Guid userId, string appCode)
        {           

            var quSectionList = new List<QuickUpdateSection>();
            var quUserSectionList = new List<UserQuickUpdateSection>();

            SqlParameter[] parameters =
                {
                       new SqlParameter("@UserID", userId),
                        new SqlParameter("@AppCode", appCode)

                    };
            quUserSectionList = await unitOfWork.GetRepository<Domain.UserQuickUpdateSection>().ExecuteReaderAsync<Domain.UserQuickUpdateSection>("[dbo].GetAllUserQuickUpdateSectionByUserAppCode", parameters);

            quSectionList = await unitOfWork.GetRepository<Domain.QuickUpdateSection>().GetAllAsync();

            foreach (var item in quSectionList)
            {

            }


            return quUserSectionList;
        }
    }
}
