using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;
using System;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class QRCodeScannerv2 : MonoBehaviour
{
    public void OnBeforeFocusChange(FocusEventData eventData) { }

    public void OnFocusEnter(FocusEventData eventData)
    {
        if (eventData.NewFocusedObject != null)
        {
            if (eventData.NewFocusedObject.name == "QRCodeGenerator")
            {
                // Access the encoded data from the QRCodeGenerator script
                QRCodeGenerator qrGenerator = eventData.NewFocusedObject.GetComponent<QRCodeGenerator>();
                if (qrGenerator != null)
                {
                    string encodedData = qrGenerator.GenerateQRCodeData;
                    Debug.Log("QR Code Data: " + encodedData);

                    // Implement actions based on the encoded data
                    UseQRCodeData(encodedData);
                }
            }
        }
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