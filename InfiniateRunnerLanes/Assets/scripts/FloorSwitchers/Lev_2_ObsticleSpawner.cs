using UnityEngine;
using System.Collections;

public class Lev_2_ObsticleSpawner : MonoBehaviour
{

    //might spawn random obsticle at center of walls
    public GameObject FanPrefab;
    public GameObject farFanPrefab;

    public GameObject HolePrefab;
    public GameObject farHolePrefab;

	public GameObject CubePrefab;
	public GameObject farCubePrefab;

	public GameObject SweepPrefab;
	public GameObject farSweepPrefab;

	


    private GameObject chosenPickup;

    private GameObject instaPrefab;
    private GameObject instafarPrefab;



    /// <summary>
    /// Pick the Spawn Obsticle at roandom possibility and spawn it and its clone as child
    /// </summary>
    public void SpawnObsticle()
    {

        int Rand = Random.Range(0, 100);

        if (Rand <= 10)
        {
			chosenPickup = CubePrefab;

        }
        else if (Rand >= 11 && Rand <= 20)
        {
			chosenPickup = HolePrefab;
        }
        else if (Rand >= 21 && Rand <= 30)
        {
			chosenPickup = FanPrefab;
		}else if (Rand >= 31 && Rand <= 40)
		{
			chosenPickup = SweepPrefab;
		}
		else if (Rand >= 41 && Rand <= 50)
		{
			chosenPickup = SweepPrefab;
		}else if (Rand >= 51)
		{
			chosenPickup = null;
		}
		
		
		Vector3 pos = transform.position;
        if (chosenPickup == HolePrefab)
        {
           instaPrefab= Instantiate(HolePrefab, new Vector3(pos.x,pos.y-50f,pos.z), Quaternion.Euler(0, 90, 0)) as GameObject;
            instafarPrefab = Instantiate(farHolePrefab, new Vector3(pos.x, pos.y - 50f, pos.z+800), Quaternion.Euler(0, 90, 0)) as GameObject;

            instafarPrefab.transform.parent = instaPrefab.transform;
        }
        else if (chosenPickup == FanPrefab)
        {


            instaPrefab = Instantiate(FanPrefab, new Vector3(pos.x+50, pos.y - 50, pos.z-15), Quaternion.Euler(0, 90, 0)) as GameObject;
            instafarPrefab = Instantiate(farFanPrefab, new Vector3(pos.x+50, pos.y - 50, pos.z+785), Quaternion.Euler(0, 90, 0)) as GameObject;
            instafarPrefab.transform.parent = instaPrefab.transform;
        }
		else if (chosenPickup == CubePrefab)
		{
			Vector3 startPos= new Vector3(pos.x+Random.Range(30,70), pos.y+Random.Range(-110,-10) , pos.z-50);
			Debug.Log (startPos);
			instaPrefab = Instantiate(CubePrefab, startPos, Quaternion.Euler(0, 0, 0)) as GameObject;
			instafarPrefab = Instantiate(farCubePrefab, new Vector3(pos.x+50, pos.y-70, pos.z+750), Quaternion.Euler(0, 0, 0)) as GameObject;

			instafarPrefab.transform.parent = instaPrefab.transform;
		}
		else if (chosenPickup == SweepPrefab)
		{
			Vector3 startPos= new Vector3(pos.x+Random.Range(-20,20), pos.y+Random.Range(-70,-30) , pos.z-50);
			instaPrefab = Instantiate(SweepPrefab, startPos , Quaternion.Euler(0, 0, 0)) as GameObject;
			instafarPrefab = Instantiate(farSweepPrefab, new Vector3(startPos.x, startPos.y, startPos.z+750), Quaternion.Euler(0, 0, 0)) as GameObject;
			instafarPrefab.transform.parent = instaPrefab.transform;
		}
		else if (chosenPickup != null)
		{
            // Instantiate(chosenPickup, new Vector3(pos.x + Random.Range(0, 80), pos.y + Random.Range(-100, 0), pos.z + Random.Range(-3, 3)), Quaternion.identity);
          //  Instantiate(chosenPickup, pos, Quaternion.identity);
        }



    }
}
