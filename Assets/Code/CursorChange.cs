using UnityEngine;

public class CambiarCursor : MonoBehaviour
{
    public Texture2D cursorNormal; // Cursor por defecto
    public Texture2D cursorSobreObjeto; // Cursor cuando está sobre el objeto
    private bool enSubescena = false; // Variable para controlar si estamos en una subescena

    private void Start()
    {
        // Restablecer el cursor al inicio de la escena
        ResetCursor();
    }

    private void OnMouseEnter()
    {
        // Si estamos en una subescena, no cambiamos el cursor, solo lo hacemos si estamos fuera de ella
        if (!enSubescena)
        {
            Cursor.SetCursor(cursorSobreObjeto, Vector2.zero, CursorMode.Auto);
        }
    }

    private void OnMouseExit()
    {
        // Solo volvemos al cursor normal si no estamos en una subescena
        if (!enSubescena)
        {
            Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto);
        }
    }

    // Llamar a esta función cuando entras o sales de una subescena
    public void CambiarA_Subescena(bool estadoSubescena)
    {
        enSubescena = estadoSubescena;

        if (enSubescena)
        {
            // Cambiar el cursor cuando entras en una subescena
            Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            // Volver al cursor por defecto cuando salgas de la subescena
            Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto);
        }
    }

    // Resetear el cursor (en caso de que se necesite reiniciar al cambiar a una subescena)
    public void ResetCursor()
    {
        Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto);
    }
}
