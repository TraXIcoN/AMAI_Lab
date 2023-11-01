using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;
using System;
public class QRCodeGenerator :MonoBehaviour
{
    public RawImage qrimage;

    void Start()
    {
        string assetName = "Beam";

        // Generate the QR code with the asset name
        Texture2D qrCodeTexture = GenerateQRCode(assetName);

        // Set the QR code texture to a RawImage component
        qrimage.texture = qrCodeTexture;
        string qrCodeData = "LoadAsset:" + assetName;
        Debug.Log("QR Code Data: " + qrCodeData);
    }

    private Texture2D GenerateQRCode(string assetName)
    {
        BarcodeWriter barcodeWriter = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
                {
                    Width = 256,
                    Height = 256
                }
        };

        // Construct the data to encode in the QR code
        string qrCodeData = "LoadAsset:" + assetName;

        Color32[] pixels = barcodeWriter.Write(qrCodeData);

        Texture2D qrCodeTexture = new Texture2D(256,256);
        qrCodeTexture.SetPixels32(pixels);
        qrCodeTexture.Apply();  

        return qrCodeTexture;
    }
    public string getAssetName()
    {
        string assetName ="Beam";
        return assetName;
    } 
    public string GenerateQRCodeData()
    {
        // You can generate and return the QR code data here
        string assetName = "Beam"; // Or any other data you want to encode
        string qrCodeData = "LoadAsset:" + assetName;
        return qrCodeData;
    }
}



