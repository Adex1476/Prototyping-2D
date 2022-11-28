using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownPlayerKind : MonoBehaviour
{
    [SerializeField] private TextMeshPro _pk;
    public string pkui;

    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();

        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("Fighter");
        items.Add("Builder");
        items.Add("Racist");
        items.Add("Mistborn");

        foreach(var item in items) { dropdown.options.Add(new Dropdown.OptionData() { text = item }); }

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    void DropdownItemSelected (Dropdown dropdown)
    {
        int index = dropdown.value;
        _pk.text = dropdown.options[index].text;
    }
}
