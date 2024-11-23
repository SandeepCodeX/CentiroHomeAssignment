using CentiroHomeAssignment.Models;
using System.Collections.Generic;

namespace CentiroHomeAssignment.Interface
{
    public interface IDataLoadService
    {
        List<FileModel> DataLoad(string fileTypeToLoad);
    }
}
