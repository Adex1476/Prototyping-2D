using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownMode : MonoBehaviour
{
    public static int mode;
    private bool created = false;

    void Awake()
    {
        if (created!) { DontDestroyOnLoad(this.gameObject); }
    }

    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();

        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("Mode 1");
        items.Add("Mode 2");

        foreach (var item in items) { dropdown.options.Add(new Dropdown.OptionData() { text = item }); }

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    void DropdownItemSelected(Dropdown dropdown)
    {
        int index = dropdown.value;
        if (dropdown.options[index].text == "Mode 1")
        {
            mode = 1;
        }
        else if (dropdown.options[index].text == "Mode 2")
        {
            mode = 2;
        }
        PlayerPrefs.SetInt("Mode", mode);
    }
}
