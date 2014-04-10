using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{

    public GameObject towerFactoryPrefab;
    public GameObject towerFactory;

    public GameObject parentFactory;


    public int buttonId;

    public int currentStructureLevel;
    public int currentStructureType;
    public GameObject currentStructure;

    // Use this for initialization
    void Start()
    {
        towerFactory = (GameObject)Instantiate(towerFactoryPrefab);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Vector3 slotCo = currentStructure.transform.position;
        slotCo.y += 0.15f;
        slotCo.z -= 0.2f;

        if (currentStructureType >= 0 && currentStructureType <= 2)
        {
            currentStructure.GetComponent<TowerScript>().hasUpgraded = true;

            switch (buttonId)
            {
                case 0:
                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, currentStructureType, currentStructureLevel + 1, currentStructure, false, 0);
                    break;
                case 1:
                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, currentStructureType, currentStructureLevel + 2, currentStructure, false, 0); ;
                    break;
                case 2:
                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, currentStructureType, currentStructureLevel + 3, currentStructure, false, 0);
                    break;
            }
        }

        else if (currentStructureType == 3)
        {
            currentStructure.GetComponent<BuildingScript>().hasUpgraded = true;

            switch (buttonId)
            {
                case 0:
                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, currentStructureType, currentStructureLevel + 1, currentStructure, true, 0);
                    break;
                case 1:
                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, currentStructureType, currentStructureLevel + 2, currentStructure, true, 0);
                    break;
                case 2:
                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, currentStructureType, currentStructureLevel + 3, currentStructure, true, 0);
                    break;
                case 3:
                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, currentStructureType, currentStructureLevel + 4, currentStructure, true, 0);
                    break;
                case 4:
                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, currentStructureType, currentStructureLevel + 5, currentStructure, true, 0);
                    break;
                case 5:
                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, currentStructureType, currentStructureLevel + 6, currentStructure, true, 0);
                    break;
            }
        }

        parentFactory.GetComponent<ButtonFactory>().deleteButtons();
    }

    public void destroyTowerFactory()
    {
        Destroy(towerFactory);
    }

    public void setup(int buttonId, GameObject currentStructure, int currentType, int currentLevel, GameObject parentFactory)
    {
        this.buttonId = buttonId;
        this.currentStructure = currentStructure;
        this.currentStructureLevel = currentLevel;
        this.currentStructureType = currentType;
        this.parentFactory = parentFactory;
    }


}
