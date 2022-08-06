using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    #region Admin
    public enum AdminOptions
    {
        Logout = 1,
        BackMainMenu = 0,
    }
    #endregion

    #region Drug
    public enum DrugOptions
    {
        CreateDrug = 1,
        UpdateDrug,
        DeleteDrug,
        GetAllDrug,
        GetAllDrugsByStore,
        DrugFilter,
        BackMainMenu = 0,
    }
    #endregion

    #region Druggist
    public enum DruggistOptions
    {
        CreateDruggist = 1,
        UpdateDruggist,
        DeleteDruggist,
        GetAllDruggist,
        GetAllDruggistByDrugStore,
        BackToMainMenu = 0,
    }
    #endregion

    #region Drugstore
    public enum DrugstoreOptions
    {
        CreateDrugstore = 1,
        UpdateDrugstore,
        DeleteDrugstore,
        GetAllDrugstore,
        GetAllDrugstoreByOwner,
        DrugstoreSale,
        BackToMainMenu = 0,
    }
    #endregion

    #region Owner
    public enum OwnerOptions
    {
        CreateOwner = 1,
        UpdateOwner,
        DeleteOwner,
        GetAllOwner,
        BackToMainMenu = 0,
    }
    #endregion


}

