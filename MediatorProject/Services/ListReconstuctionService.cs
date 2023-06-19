using MediatorProject.Models;

namespace MediatorProject.Services
{
    public class ListReconstuctionService
    {
        public List<ReturnData> RebuildData(ListParsingModels model)
        {
            List<ReturnData> returnDataList = new List<ReturnData>();
            returnDataList.Add(new ReturnData()
            {
                nameData = model.NameData,
                descData = model.DescData,
            });
            return returnDataList;
        }
    }
}
