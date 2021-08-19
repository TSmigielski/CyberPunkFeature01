using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Player Equipment/Gun")]
public class GunData : EquipmentData
{
    public float damage;
    public float roundsPerMinute;
    public int magazineSize;
    public int maxAmmo;
    public bool isAutomatic;
}
