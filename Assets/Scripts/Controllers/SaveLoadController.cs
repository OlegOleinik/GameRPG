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
        GameManager.ClickPlay();
        saved = new SavedGame();
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
    }
    public void Load(string fileName)
    {
        GameManager.ClickPlay();
        saved = JsonUtility.FromJson<SavedGame>(BinaryToString(File.ReadAllText(Application.persistentDataPath + "/Saves/" + fileName)));
        saved.DoLoad();
    }


    public void SetPlayerDefault()
    {
        Inventory inventory = GameManager.player.GetComponent<Inventory>();
        inventory.inventorySlots = new List<InventorySlot>();
        AttackController attackController = GameManager.player.GetComponentInChildren<AttackController>();
        attackController.sword.SetSword(Resources.Load<SwordScriptableObject>($"Items/Sword/WoodSword"));
        attackController.SwitchWeaponReady(true);
        Player player = GameManager.player.GetComponent<Player>();
        player.SetDefaultStats();
        player.money = 10;
        player.specsPoints = 0;
        player.currentHP = player.maxHP;
        player.currentStamina = player.maxStamina;
        player.currentMagic = player.maxMagic;
        player.experience = 0;
        player.requiredExperience = 10;
        player.lvl = 0;
        player.rollCollDown = 0;
        GameManager.UI.GetComponentInChildren<UIScript>().GetMagicUpPanel().SetDefaultLvls();
        QuestsController questsController = GameManager.player.GetComponent<QuestsController>();
        questsController.activeQuests.Clear();
        questsController.completedQuests.Clear();
        questsController.ClearPanel();
        NPCController nPCController = GameManager.player.GetComponent<NPCController>();
        for (int i = 0; i < nPCController.nPCs.Length; i++)
        {
            nPCController.nPCs[i].SetDefault();
        }
        foreach (var item in GameObject.FindGameObjectsWithTag("Quest"))
        {
           Destroy(item);
        }
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
    public bool isWeaponInHand;
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
    public float time;
    public float dayColorR;
    public float dayColorG;
    public float dayColorB;
    public void DoSave()
    {
        sceneName = Mathf.Round(GameManager.player.transform.position.x / 24) + "." + Mathf.Round(GameManager.player.transform.position.y / 24);
        x = GameManager.player.transform.position.x;
        y = GameManager.player.transform.position.y;
        foreach (var item in GameManager.player.GetComponent<Inventory>().inventorySlots)
        {
            SavedItem newItem = new SavedItem(item.ItemScriptableObject.type, item.ItemScriptableObject.name, item.count);
            savedItems.Add(newItem);
        }
        AttackController attackController = GameManager.player.GetComponentInChildren<AttackController>();
        ItemScriptableObject sword = attackController.sword.GetSword();
        isWeaponInHand = attackController.isWeaponInHand;
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
            string savedDialog = "";
            if(item.startDialogueSentence != null)
            {
                savedDialog = item.startDialogueSentence.name;
            }
            SavedNPC newSavedNPC = new SavedNPC(item.isDead, savedDialog);
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
        GlobalLightController globalLightController = GameObject.FindWithTag("GlobalLight").GetComponent<GlobalLightController>();
        time = globalLightController.currentTime;
        Color saveColor = globalLightController.currentColor;
        dayColorR = saveColor.r;
        dayColorG = saveColor.g;
        dayColorB = saveColor.b;
    }

    public void DoLoad()
    {
        SceneManager.LoadScene(sceneName);
        GameManager.player.transform.position = new Vector2(x, y);
        Inventory inventory = GameManager.player.GetComponent<Inventory>();
        inventory.inventorySlots.Clear();
        foreach (var item in savedItems)
        {
            inventory.inventorySlots.Add(new InventorySlot(Resources.Load<ItemScriptableObject>($"Items/{item.itemType}/{item.itemName}"), item.count));
        }
        AttackController attackController = GameManager.player.GetComponentInChildren<AttackController>();
        attackController.sword.SetSword(Resources.Load<SwordScriptableObject>($"Items/{savedSword.itemType}/{savedSword.itemName}"));
        attackController.SwitchWeaponReady(isWeaponInHand);
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
        GlobalLightController globalLightController = GameObject.FindWithTag("GlobalLight").GetComponent<GlobalLightController>();
        globalLightController.LoadTime(time, new Color(dayColorR, dayColorG, dayColorB));
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