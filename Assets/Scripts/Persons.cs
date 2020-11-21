using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Persons : MonoBehaviour
{
    public Text incomeText, moneyText;
    public int income, money; 

    private void Start()
    {
        VariationOfPersons();
        moneyText.text = "Money " + Bridge.money.ToString(); 
    }

    public void One()
    {
        Hero hero = new Hero(new PersonOne());
        Bridge.color = hero.ItemsCreate();
        Bridge.i = hero.LevelCreate();
    }

    public void Two()
    {
        Hero hero = new Hero(new PersonTwo());
        Bridge.color = hero.ItemsCreate();
        Bridge.i = hero.LevelCreate();
    }

    public void Three()
    {
        Hero hero = new Hero(new PersonThree());
        Bridge.color = hero.ItemsCreate();
        Bridge.i = hero.LevelCreate();
    }

    public void CreateLevelandItems()
    {
        SceneManager.LoadScene(1);
    }

    private void VariationOfPersons()
    {
        Bridge.income = Random.Range(50, 150);
        income = Bridge.income;
        incomeText.text ="Income " +  income.ToString(); 
        int index = Random.Range(0, 3);
        if (index == 0)
            One();
        if (index == 1)
            Two();
        if (index == 2)
            Three();
    }

    public void Skip()
    {
        VariationOfPersons();
    }
}

#region Person

public abstract class PersonFactory
{
    public abstract Items CreateItems();
    public abstract Level CreateLevel();
}

class PersonOne : PersonFactory
{
    public override Items CreateItems()
    {
        return new Red();
    }

    public override Level CreateLevel()
    {
        return new Level2x2();
    }
}

class PersonTwo : PersonFactory
{
    public override Items CreateItems()
    {
        return new Yellow();
    }

    public override Level CreateLevel()
    {
        return new Level2x3();
    }
}

class PersonThree : PersonFactory
{
    public override Items CreateItems()
    {
        return new Green();
    }

    public override Level CreateLevel()
    {
        return new Level2x4();
    }
}

#endregion

#region Item and Level

public abstract class Items
{
    public abstract Color TypeItem();
}

public abstract class Level
{
    public abstract int TypeLevel();
}

class Red : Items
{
    public override Color TypeItem()
    {
        return new Color(0.2F, 0.3F, 0.4F);
    }
}

class Yellow : Items
{
    public override Color TypeItem()
    {
        return new Color(0.2F, 0.1F, 0.3F);
    }
}

class Green : Items
{
    public override Color TypeItem()
    {
        return new Color(0.6F, 0.3F, 0.9F);
    }
}

class Level2x2 : Level
{
    public override int TypeLevel()
    {
        return 0;
    }
}

class Level2x3 : Level
{
    public override int TypeLevel()
    {
        return 1;
    }
}

class Level2x4 : Level
{
    public override int TypeLevel()
    {
        return 2;
    }
}

#endregion

class Hero
{
    public Items items;
    public Level level;
    public Hero(PersonFactory person)
    {
        items = person.CreateItems();
        level = person.CreateLevel();
    }

    public Color ItemsCreate()
    {
        return items.TypeItem();
    }

    public int LevelCreate()
    {
        return level.TypeLevel();
    }
}