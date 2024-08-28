using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DropdownHandler : MonoBehaviour
{
    public Dropdown myDropdown;

    // Diccionario para almacenar las descripciones (uso esto en vez del enum de abajo porq los enum solo dejan poner una sola palabra.)
    private Dictionary<OptionsEnum, string> descriptions = new Dictionary<OptionsEnum, string>()
    {
        { OptionsEnum.Opcion1, "Jacob O’Neill" },
        { OptionsEnum.Opcion2, "Oscar Jones" },

    };

    void Start()
    {
        PopulateDropdown();
        myDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    void PopulateDropdown()
    {
        List<string> options = new List<string>();
        foreach (OptionsEnum option in System.Enum.GetValues(typeof(OptionsEnum)))
        {
            if (descriptions.TryGetValue(option, out string description))
            {
                options.Add(description);
            }
        }

        myDropdown.ClearOptions();
        myDropdown.AddOptions(options);
    }

    void OnDropdownValueChanged(int index)
    {
        OptionsEnum selectedOption = (OptionsEnum)index;
        if (descriptions.TryGetValue(selectedOption, out string description))
        {
            Debug.Log($"Selected option: {selectedOption} - Description: {description}");
        }
        else
        {
            Debug.LogWarning("No description found for the selected option.");
        }
    }


    // esta es la cantidad de opciones

public enum OptionsEnum
    {
        Opcion1,
        Opcion2,
    }

}
