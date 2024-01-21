using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SMObjectManager : MonoBehaviour
{
    #region singleton
    public static SMObjectManager instance;
    #endregion
    #region Private Variables
    [SerializeField] private GameObject block;
    [SerializeField] public GameObject initialBlock;

    private List<GameObject> blocksList = new List<GameObject>();
    #endregion

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenerateBlock()
    {
        Vector3 blockPosition = GenerateRandomPosition(true);
        GenerateRandomSizeForBlock();
        GameObject blockObject = Instantiate(block, blockPosition, Quaternion.identity);
        blocksList.Add(blockObject);
    }
    private void GenerateRandomSizeForBlock()
    {
        block.transform.localScale = new Vector3(Random.Range(0.5f, 1.5f), block.transform.localScale.y, block.transform.localScale.z);
    }
    private Vector3 blockPosition;
    private Vector3 GenerateRandomPosition(bool _starting)
    {
        float randomValue;
        if (_starting)
        {
            randomValue = Random.Range(-.5f, 2f);
            blockPosition = new Vector3(randomValue, -3.5f, 0f);
        }
        else
        {
            randomValue = Random.Range(-2f, 2f);
            blockPosition = new Vector3(randomValue, -3.5f, 0f);
        }
        return blockPosition;
    }
    internal GameObject GetCurrentBlock()
    {
        return blocksList[0];
    }
    internal Vector3 GetSpawnPositionFromBlock(GameObject _block)
    {
       return new Vector3(_block.transform.position.x +(_block.transform.localScale.x / 2) , _block.transform.position.y + 1.5f, block.transform.position.z);
    }


}
