using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabasePresenter
{
    private readonly DatabaseModel _model;

    public DatabasePresenter(DatabaseModel model)
    {
        _model = model;
    }

    #region Output

    public event Action<List<string>> OnGetCountries;
    public event Action OnErrorGetCountries;

    public event Action<string> OnGetLink;
    public event Action OnErrorGetLink;

    #endregion

    #region Input

    public void GetCountries()
    {

    }

    public void GetLink()
    {

    }

    #endregion
}
