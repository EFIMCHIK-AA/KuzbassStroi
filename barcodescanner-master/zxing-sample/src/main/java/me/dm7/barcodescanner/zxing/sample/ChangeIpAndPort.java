package me.dm7.barcodescanner.zxing.sample;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;
import java.util.regex.Pattern;

public class ChangeIpAndPort extends MainActivity {
    public static boolean writeIpAndPort = true;
    //Перегрузка метода создание данного лейаута
    @Override
    public void onCreate(Bundle state) {
        super.onCreate(state);
        setContentView(R.layout.change_ip_and_port);
        setupToolbar();
        //Создание кнопки назад в тулбаре
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        getSupportActionBar().setDisplayShowHomeEnabled(true);
        //Разрешение на запись айпи и порта
        writeIpAndPort = true;
        //Импортирование айпи и порта из памяти телефона
        impOrt();
    }
    //Перегрузка метода для создания пунктов меню, в данном методе убираются пункты
    @SuppressLint("ResourceType")
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.layout.main_menu, menu);
        MenuItem action_btn = menu.findItem(R.id.action_settings);
        action_btn.setVisible(false);
        return true;
    }
    //Загрузка тулбара
    public void setupToolbar() {
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar1);
        setSupportActionBar(toolbar);
    }
    //Перегрузка метода для возвращения на главную страницу
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        impOrt();
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
        finish();
        return true;
    }
    //Импортирование айпи и порта из памяти телефона
    public void impOrt(){
        SharedPreferences prefs = getSharedPreferences(MY_PREFS_NAME, MODE_PRIVATE);
        String nserver_address = prefs.getString("server", null);
        if (nserver_address != null) {
            Log.d("load server", nserver_address);
            TextView server_text = (TextView) findViewById(R.id.ip_text);
            server_text.setText(nserver_address);
        }
        Integer nserver_port = prefs.getInt("port", 3333);
        if (nserver_port != 3333) {
            Log.d("load port", nserver_port.toString());
            TextView port_text = (TextView) findViewById(R.id.port_text);
            port_text.setText(nserver_port.toString());
        }
    }
    //Метод для сохранения введеных айпи и порта и выход после этого на главную страницу
    public void tomain(View v) {
        saveipandport();
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
        this.finish();
    }
    //Метод сохранения айпи и порта
    public void saveipandport() {

        try
        {
            TextView server_text = (TextView) findViewById(R.id.ip_text);
            TextView port_text = (TextView) findViewById(R.id.port_text);
            //Проверка на правильность ввода айпи и порта
            String Temp=server_text.getText().toString();
            String[] Item = Temp.split(Pattern.quote("."));
            String ResultString =  Item[0] + Item[1] + Item[2] + Item[3];
            Long num = Long.parseLong(ResultString);
            for(int i=0;i<4;i++)
            {
                if (Integer.parseInt(Item[i]) > 255 || Integer.parseInt(Item[i]) < 0)
                    throw new Exception();
            }
            SimpleScannerActivity.server_address = server_text.getText().toString();
            SimpleScannerActivity.server_port = Integer.parseInt(port_text.getText().toString());
            SharedPreferences.Editor editor = getSharedPreferences(MY_PREFS_NAME, MODE_PRIVATE).edit();
            editor.putString("server", SimpleScannerActivity.server_address);
            editor.putInt("port", SimpleScannerActivity.server_port);
            editor.commit();


        }
        catch (Exception e)
        {
            Toast toast = Toast.makeText(getApplicationContext(),
                    "Ошибка сохранения ip и port, непровельно введен ip или port. Например, ip "+"192.168.0.1"+",port "+"48677", Toast.LENGTH_LONG);
            toast.show();
        }
    }
}
