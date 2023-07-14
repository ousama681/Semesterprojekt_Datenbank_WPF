using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Ui.Models;

namespace WPF_Ui.Services.Data.Interfaces
{
    public interface ITownRepository :IDBRepository<Town>
    {
        List<string> GetAllZipCodes();
    }
}
