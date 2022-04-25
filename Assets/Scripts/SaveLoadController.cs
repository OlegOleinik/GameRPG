using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using System.Text;
public class SaveLoadController : MonoBehaviour
{

    SavedGame saved;
    public void Save(string fileName)
    {
        saved = new SavedGame();
      //  Mathf.Round(gameObject.transform.position.x / 12);
       

        saved.DoSave();

        if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
        }
        if (!File.Exists(Application.persistentDataPath + "/Saves/" + fileName))
        {
            File.Create(Application.persistentDataPath + "/Saves/" +  fileName).Close();
        }
        
        File.WriteAllText(Application.persistentDataPath + "/Saves/" + fileName,  string.Join("",StringToBinary(JsonUtility.ToJson(saved))));

        Debug.Log("Game data saved!");
    }
    public void Load(string fileName)
    {
        saved = JsonUtility.FromJson<SavedGame>(BinaryToString(File.ReadAllText(Application.persistentDataPath + "/Saves/" + fileName)));
        saved.DoLoad();
        Debug.Log("Game data loaded!");
    }



    public string StringToBinary(string data)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in data.ToCharArray())
        {
            sb.Append(System.Convert.ToString(c, 2).PadLeft(8, '0'));
        }
        return sb.ToString();
    }

    public static string BinaryToString(string data)
    {
        List<byte> byteList = new List<byte>();

        for (int i = 0; i < data.Length; i += 8)
        {
            byteList.Add(System.Convert.ToByte(data.Substring(i, 8), 2));
        }
        return Encoding.ASCII.GetString(byteList.ToArray());
    }
}

[System.Serializable]
public class SavedGame
{
    public string sceneName;
    public List<SavedItem> savedItems = new List<SavedItem>();
    public List<SavedNPC> savedNPCs = new List<SavedNPC>();
    public List<SaveActivedQuest> saveActivedQuests = new List<SaveActivedQuest>();
    public List<SavedCompletedQuest> saveCompletedQuests = new List<SavedCompletedQuest>();
    public SavedItem savedSword;

    public float x;
    public float y;

    public List<float> stats = new List<float>();



    public int money;
    public int specPoints;
    public float currentHP;
    public float currentStamina;
    public float currentMagic;
    public float experience;
    public float requiredExperience;
    public int lvl;
    public float rollCollDown;


    public List<int> magicLvls = new List<int>();


    public void DoSave()
    {

        sceneName = Mathf.Round(GameManager.player.transform.position.x / 24) + "." + Mathf.Round(GameManager.player.transform.position.y / 24);
        // Debug.Log(this.sceneName);

        x = GameManager.player.transform.position.x;
        y = GameManager.player.transform.position.y;
        foreach (var item in GameManager.player.GetComponent<Inventory>().inventorySlots)
        {
            SavedItem newItem = new SavedItem(item.ItemScriptableObject.type, item.ItemScriptableObject.name, item.count);
            savedItems.Add(newItem);
        }
        ItemScriptableObject sword = GameManager.player.GetComponentInChildren<AttackController>().sword.GetSword();
        savedSword = new SavedItem(sword.type, sword.name, 1);

        Player player = GameManager.player.GetComponent<Player>();
        foreach (var item in player.GetStats())
        {
            stats.Add(item.Value);
        }
        money = player.money;
        specPoints = player.specsPoints;
        currentHP = player.currentHP;
        currentStamina = player.currentStamina;
        currentMagic = player.currentMagic;
        experience = player.experience;
        requiredExperience = player.requiredExperience;
        lvl = player.lvl;
        rollCollDown = player.rollCollDown;
        magicLvls = GameManager.UI.GetComponentInChildren<UIScript>().GetMagicUpPanel().GetLvls();
        foreach (var item in GameManager.player.GetComponent<NPCController>().nPCs)
        {
            SavedNPC newSavedNPC = new SavedNPC(item.isDead, item.startDialogueSentence.name);
            savedNPCs.Add(newSavedNPC);
        }

        QuestsController questsController = GameManager.player.GetComponent<QuestsController>();
        foreach (var item in questsController.activeQuests)
        {
            SaveActivedQuest saveActivedQuest = new SaveActivedQuest(item.stage, item.quest.name);
            saveActivedQuests.Add(saveActivedQuest);
        }
        foreach (var item in questsController.completedQuests)
        {
            SavedCompletedQuest savedCompletedQuest = new SavedCompletedQuest(item.quest.name);
            saveCompletedQuests.Add(savedCompletedQuest);
        }

    }

    public void DoLoad()
    {

        // SceneManager.LoadScene("0.0");

        SceneManager.LoadScene(sceneName);



        //SceneManager.LoadScene("0.0");
        GameManager.player.transform.position = new Vector2(x, y);
        Inventory inventory = GameManager.player.GetComponent<Inventory>();
        inventory.inventorySlots.Clear();
        foreach (var item in savedItems)
        {
            inventory.inventorySlots.Add(new InventorySlot(Resources.Load<ItemScriptableObject>($"Items/{item.itemType}/{item.itemName}"), item.count));
        }
        GameManager.player.GetComponentInChildren<AttackController>().sword.SetSword(Resources.Load<SwordScriptableObject>($"Items/{savedSword.itemType}/{savedSword.itemName}"));
    
        Player player = GameManager.player.GetComponent<Player>();
        player.SetStats(stats);
        player.money = money;
        player.specsPoints = specPoints;
        player.currentHP = currentHP;
        player.currentStamina = currentStamina;
        player.currentMagic = currentMagic;
        player.experience = experience;
        player.requiredExperience = requiredExperience;
        player.lvl = lvl;
        player.rollCollDown = rollCollDown;
        GameManager.UI.GetComponentInChildren<UIScript>().GetMagicUpPanel().SetLvls(magicLvls);
        NPCController nPCController = GameManager.player.GetComponent<NPCController>();
        for (int i = 0; i < Mathf.Min(savedNPCs.Count, nPCController.nPCs.Length); i++)
        {
            nPCController.nPCs[i].isDead = savedNPCs[i].isDesd;
            nPCController.nPCs[i].startDialogueSentence = Resources.Load<ADialogueSentence>($"DialogueSentences/{savedNPCs[i].startDialogueSentenceName}");
        }


        QuestsController questsController = GameManager.player.GetComponent<QuestsController>();
        questsController.activeQuests.Clear();
        questsController.completedQuests.Clear();
        questsController.ClearPanel();
        foreach (var item in GameObject.FindGameObjectsWithTag("Quest"))
        {
            GameObject.Destroy(item);
        }
        foreach (var item in saveActivedQuests)
        {
            GameObject quest = GameObject.Instantiate((Resources.Load<QuestScriptableObject>($"Quests/{item.quest}")).quest);
            quest.GetComponent<AQuest>().SetStage(item.stage);
            questsController.AddQuest(quest);
        }
        foreach (var item in saveCompletedQuests)
        {
            CompletedQuest completedQuest = new CompletedQuest((Resources.Load<QuestScriptableObject>($"Quests/{item.quest}")).quest.GetComponent<AQuest>());
            questsController.AddCompletedQuest(completedQuest);
        }
    }

}
[System.Serializable]
public class SavedItem
{
    public string itemType;
    public string itemName;
    public int count;
    public SavedItem(string itemType, string itemName, int count)
    {
        this.itemType = itemType;
        this.itemName = itemName;
        this.count = count;
    }

}
[System.Serializable]
public class SavedNPC
{
    public bool isDesd;
    public string startDialogueSentenceName;
    public SavedNPC(bool isDesd, string startDialogueSentenceName)
    {
        this.isDesd = isDesd;
        this.startDialogueSentenceName = startDialogueSentenceName;

    }

}
[System.Serializable]
public class SaveActivedQuest
{
    public int stage;
    public string quest;
    public SaveActivedQuest(int stage, string quest)
    {
        this.stage = stage;
        this.quest = quest;
    }

}

[System.Serializable]
public class SavedCompletedQuest
{
    public string quest;
    public SavedCompletedQuest(string quest)
    {
        this.quest = quest;
    }

}