using System.Collections.Generic;
using UnityEngine;

public partial class ModelAudition
{
    private static Dictionary<string, ModelAudition> _modelByType = null;

    public static ModelAudition GetByAuditionType(string auditionType)
    {
        if (_modelByType == null) {
            _modelByType = new();
            foreach (var a in _map.Values) {
                _modelByType.Add(a.AuditionType, a);
            }
        }

        _modelByType.TryGetValue(auditionType, out var audition);
        if (audition == null) {
            Debug.LogError(auditionType);
        }

        return audition;
    }
}