using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malee;
using Malee.List;

[CreateAssetMenu()]
public class AchievementDatabase : ScriptableObject
{
    [Reorderable(sortable = false, paginate = false, elementIconPath = "")]
    public AchievementsArray achievements;

    [System.Serializable]
    public class AchievementsArray : ReorderableArray<Achievement> {    }
}
//Code by Salma Elabsi