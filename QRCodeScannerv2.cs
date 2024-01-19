using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;
using System;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class QRCodeScannerv2 : MonoBehaviour, IMixedRealityPointerHandler
{
    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        // Check if the touched object is the "QRCodeGenerator"
        if (eventData.Pointer.Result.CurrentPointerTarget != null)
        {
            if (eventData.Pointer.Result.CurrentPointerTarget.name == "QRCodeGenerator")
            {
                // Access the encoded data from the QRCodeGenerator script
                //QRCodeGenerator qrGenerator = eventData.Pointer.Result.CurrentPointerTarget.GetComponent<QRCodeGenerator>();
                    string encodedData =QRCodeGenerator.GenerateQRCodeData();
                    Debug.Log("QR Code Data: " + encodedData);

                    // Implement actions based on the encoded data
                    UseQRCodeData(encodedData);
                
            }
        }
    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
    // This method is intentionally left empty because you don't need any specific actions when the pointer goes down.
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
    // This method is intentionally left empty because you don't need any specific actions during dragging.
    }   
    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
    // This method is intentionally left empty because you don't need any specific actions when the pointer goes up.
    }

    private void UseQRCodeData(string encodedData)
    {
    // Check if the QR code data starts with "LoadAsset:"
    if (encodedData.StartsWith("LoadAsset:"))
    {
        // Extract the asset name by removing "LoadAsset:" from the beginning
        string assetName = encodedData.Substring("LoadAsset:".Length);

        // Load the asset based on the assetName
        GameObject loadedAsset = Resources.Load<GameObject>(assetName);

        if (loadedAsset != null)
        {
            // Instantiate the loaded asset in the scene
            Instantiate(loadedAsset);
        }
        else
        {
            Debug.LogError("Asset not found: " + assetName);
        }
    }
    else
    {
        Debug.LogError("Invalid QR code data format");
    }
    }
}
}
