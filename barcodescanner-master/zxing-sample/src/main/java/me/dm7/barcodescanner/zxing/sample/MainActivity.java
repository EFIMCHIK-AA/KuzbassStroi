package me.dm7.barcodescanner.zxing.sample;

import android.Manifest;
import android.annotation.SuppressLint;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.wifi.WifiManager;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Message;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.Toast;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.net.InetAddress;
import java.net.InetSocketAddress;
import java.net.NetworkInterface;
import java.net.Socket;
import java.net.SocketAddress;
import java.net.SocketException;
import java.util.Enumeration;
import java.util.regex.Pattern;

import android.content.SharedPreferences;
import android.os.Build;
import android.support.annotation.RequiresApi;
import android.widget.EditText;
import android.widget.TextView;

import com.google.zxing.FormatException;
import com.google.zxing.Result;

import me.dm7.barcodescanner.zxing.ZXingScannerView;

public class MainActivity extends AppCompatActivity {
    private static final int ZXING_CAMERA_PERMISSION = 1;
    public static final String MY_PREFS_NAME = "MyPrefsFile";
    private Class<?> mClss;

//Создание лейаута и импорт айпи и порта в переменные
    @Override
    public void onCreate(Bundle state) {
        super.onCreate(state);
        setContentView(R.layout.activity_main);
        setupToolbar();
        SharedPreferences prefs = getSharedPreferences(MY_PREFS_NAME, MODE_PRIVATE);
        String nserver_address = prefs.getString("server", null);
        if (nserver_address != null) {
            Log.d("load server", nserver_address);
            SimpleScannerActivity.server_address=nserver_address;
        }
        Integer nserver_port = prefs.getInt("port", 3333);
        if (nserver_port != 3333) {
            Log.d("load port", nserver_port.toString());
            SimpleScannerActivity.server_port=nserver_port;
        }
        ChangeIpAndPort.writeIpAndPort = false;
        }
        //Создание пунктов меню
    @SuppressLint("ResourceType")
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.layout.main_menu, menu);
        return true;
    }

    public void setupToolbar() {
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
    }
    //Метод перехода к сканеру
    public void launchSimpleActivityBlank(View v) {

        SimpleScannerActivity.scan=false;
        launchActivity(SimpleScannerActivity.class);
    }
    public void launchSimpleActivityChert(View v) {

        SimpleScannerActivity.scan=true;
        launchActivity(SimpleScannerActivity.class);
    }
//Запуск класса и проверка прав на использование камеры
    public void launchActivity(Class<?> clss) {
        if (ContextCompat.checkSelfPermission(this, Manifest.permission.CAMERA)
                != PackageManager.PERMISSION_GRANTED) {
            mClss = clss;
            ActivityCompat.requestPermissions(this,
                    new String[]{Manifest.permission.CAMERA}, ZXING_CAMERA_PERMISSION);
        } else {
            Intent intent = new Intent(this, clss);
            startActivity(intent);
        }
    }
//Получение прав на использование камеры
    @Override
    public void onRequestPermissionsResult(int requestCode, String permissions[], int[] grantResults) {
        switch (requestCode) {
            case ZXING_CAMERA_PERMISSION:
                if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    if (mClss != null) {
                        Intent intent = new Intent(this, mClss);
                        startActivity(intent);
                    }
                } else {
                    Toast.makeText(this, "Please grant camera permission to use the QR Scanner", Toast.LENGTH_SHORT).show();
                }
                return;
        }
    }
    //Метод перехода к классу для изменения айпи и порта
    public void change(MenuItem item) {
        Intent intent = new Intent(this, ChangeIpAndPort.class);
        startActivity(intent);
        this.finish();
    }
    //Закрытие приложения
    @RequiresApi(api = Build.VERSION_CODES.JELLY_BEAN)
    public void Finish(View v){
        finishAffinity();
        System.exit(0);
    }

}