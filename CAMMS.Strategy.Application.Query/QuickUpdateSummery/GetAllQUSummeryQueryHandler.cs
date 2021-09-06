using CAMMS.Strategy.Application.DTO;
using CAMMS.Strategy.Application.Interface;
using CAMMS.Strategy.Application.Common;
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
        private readonly ICacheData cacheData;

        public GetAllQUSummeryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheData cacheData)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.cacheData = cacheData;
        }
        public async Task<List<QuickUpdateSummeryDto>> Handle(GetAllQuickUpdateSummeryQuery request, CancellationToken cancellationToken)
        {
            var quSectionList = new List<QuickUpdateSection>();

            var quUserSectionList = new List<UserQuickUpdateSection>();

            var actionList = new List<Domain.Action>();
            List<QuickUpdateSummeryDto> QUSummeryDtoList = new List<QuickUpdateSummeryDto>();
           

            if ((request.UserId != null && request.AppCode != null) && request.AppCode == Common.Enums.ApplicationCodes.SYCLE.ToString() || request.AppCode == Common.Enums.ApplicationCodes.INTERPLAN.ToString() || request.AppCode == Common.Enums.ApplicationCodes.IPM.ToString())
            {
                List<Domain.QuickUpdateSection> QUUpdateSectionlist = await GetUserQuickUpdateSectionByAppCode(request.AppCode);
                List<Domain.UserQuickUpdateSection> UserQuickUpdateSectionlist = await GetUserQuickUpdateSectionList(request.UserId, request.AppCode);
                if (UserQuickUpdateSectionlist != null && UserQuickUpdateSectionlist.Count > 0)
                {
                    foreach (var section in QUUpdateSectionlist)
                    {
                        if (UserQuickUpdateSectionlist.Exists(u => u.QuickUpdateSectionID == section.QuickUpdateSectionID && u.IsVisible))
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
                }
                else
                {        

                    QUUpdateSectionlist = QUUpdateSectionlist.GroupBy(x => x.QuickUpdateSectionID).Select(g => g.First()).ToList();

                    foreach (var section in QUUpdateSectionlist)
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
            }
            else
            {
                quSectionList = await unitOfWork.GetRepository<Domain.QuickUpdateSection>().GetAllAsync();

                foreach (var section in quSectionList)
                {
                    if (request.AppCode == Common.Enums.ApplicationCodes.IRM.ToString() &&
                        (section.UniqueName == "MYRISKS" || section.UniqueName == "MYRISKACTIONS") ||
                        (section.UniqueName == "MYINCIDENTS" || section.UniqueName == "MYINCIDENTACTIONS") ||
                         (section.UniqueName == "MYAUTHORITYDOCUMENT" || section.UniqueName == "MYRECOMMENDATIONS")
                        )
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

                    else if (request.UserId == null && request.AppCode == null)
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
            }

           // List<Domain.LABELREPLACEMENT> ll= await cacheData.GetCacheData<Domain.LABELREPLACEMENT>("GetAllLabelReplacementQuery");

            return await Task.FromResult(QUSummeryDtoList.OrderBy(a=>a.Sort).ToList());
        }

        private async Task<List<Domain.UserQuickUpdateSection>> GetUserQuickUpdateSectionList(Guid? UserId, string AppCode)
        { 
            var quUserSectionList = new List<UserQuickUpdateSection>();

            SqlParameter[] parameters =
                                     {
                       new SqlParameter("@UserID", UserId),
                        new SqlParameter("@AppCode", AppCode)

                    };
            quUserSectionList = await unitOfWork.GetRepository<Domain.UserQuickUpdateSection>().ExecuteReaderAsync<Domain.UserQuickUpdateSection>("[dbo].GetAllUserQuickUpdateSectionByUserAppCode", parameters);

            return quUserSectionList;
        }

        private async Task<List<Domain.QuickUpdateSection>> GetUserQuickUpdateSectionByAppCode(string AppCode)
        {          

            SqlParameter[] parameters =
                            {
                               new SqlParameter("@ApplicationCode", AppCode)
                             };
            List<Domain.QuickUpdateSection> QUUpdateSectionlist = await unitOfWork.GetRepository<Domain.QuickUpdateSection>().ExecuteReaderAsync<Domain.QuickUpdateSection>("[dbo].GetQuickUpdateSectionByApplicationCode", parameters);

            return QUUpdateSectionlist;
        }
    }
}
