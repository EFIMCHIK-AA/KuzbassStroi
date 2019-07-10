package me.dm7.barcodescanner.zxing.sample;


import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.support.annotation.RequiresApi;
import android.util.Log;
import android.util.Xml;
import android.view.View;
import android.view.ViewGroup;
import android.content.DialogInterface;
import android.support.v7.app.AlertDialog;
import android.widget.Button;
import android.widget.Toast;

import com.google.zxing.Result;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.io.UnsupportedEncodingException;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.net.SocketAddress;
import java.net.SocketException;
import java.util.regex.Pattern;
import me.dm7.barcodescanner.zxing.ZXingScannerView;

public class SimpleScannerActivity extends BaseScannerActivity implements ZXingScannerView.ResultHandler {
    private ZXingScannerView mScannerView;
    public static String msg = "default";
    public static String resp = "No Response Yet\nTry Sending Some Data.";
    public static String server_address = "192.168.0.0";
    public static Integer server_port = 48677;
    public static Boolean Abort = false;
    public static LongOperation lo = null;
    public static Socket socket = null;
    public static boolean scan=true;
    @Override
    public void onCreate(Bundle state) {
        super.onCreate(state);
        setContentView(R.layout.activity_simple_scanner);
        setupToolbar();
        ViewGroup contentFrame = (ViewGroup) findViewById(R.id.content_frame);
        mScannerView = new ZXingScannerView(this);
        contentFrame.addView(mScannerView);
    }
    @Override
    public void onResume() {
        super.onResume();
        mScannerView.setResultHandler(this);
        mScannerView.startCamera();
    }

    @Override
    public void onPause() {
        super.onPause();
        mScannerView.stopCamera();
    }

    @Override
    public void handleResult(final Result result) {
        Log.d("QRCodeScanner", result.getText());
        Log.d("QRCodeScanner", result.getBarcodeFormat().toString());
        //Проверка на доступ записи айпи и порта или отправка данных на сервер
        if(ChangeIpAndPort.writeIpAndPort)
        {
            try
            {
                String Temp = result.getText();
                String[] Item = Temp.split(Pattern.quote("_"));
                server_address = Item[0];
                String[] check = Item[0].split(Pattern.quote("."));
                String ResultString =  check[0] + check[1] + check[2] + check[3];
                Long num = Long.parseLong(ResultString);
                server_port = Integer.parseInt(Item[1]);
                Toast toast = Toast.makeText(getApplicationContext(),
                                "Успешное сохранение ip " + Item[0] + " и port " + Item[1], Toast.LENGTH_LONG);
                toast.show();
                SharedPreferences.Editor editor = getSharedPreferences(MainActivity.MY_PREFS_NAME, MODE_PRIVATE).edit();
                editor.putString("server", SimpleScannerActivity.server_address);
                editor.putInt("port", SimpleScannerActivity.server_port);
                editor.commit();
                Intent intent = new Intent(this, ChangeIpAndPort.class);
                startActivity(intent);
                this.finish();
            }
            catch (Exception e)
            {
            Toast toast = Toast.makeText(getApplicationContext(),
                    "Ошибка сохранения ip и port, неправельно введен ip или port. Например, ip "+"192.168.0.1"+",port "+"48677", Toast.LENGTH_LONG);
                toast.show();
                mScannerView.resumeCameraPreview(SimpleScannerActivity.this);
            }
        }
        else {
            msg = result.getText();
            if(scan) {
                try {
                    String str = new String(msg.getBytes("ISO-8859-1"), "Cp1251");
                    msg = str;
                } catch (UnsupportedEncodingException e) {
                    e.printStackTrace();
                }
            }

            String[] protect = msg.split("_");
            Integer check = protect.length;
            if (check == 6)
            {
                sendMessage();
                Toast toast = Toast.makeText(getApplicationContext(),
                        msg, Toast.LENGTH_LONG);
                toast.show();
                mScannerView.resumeCameraPreview(SimpleScannerActivity.this);
            }
            else
            {
                final AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.setTitle("Ошибка QR кода");
                builder.setPositiveButton("Пропустить", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        mScannerView.resumeCameraPreview(SimpleScannerActivity.this);

                    }
                }).setMessage(msg+ "\nQR выполнен не по шаблону");
                AlertDialog alert1 = builder.create();
                alert1.setCanceledOnTouchOutside(false);
                alert1.show();
            }

        }

    }
    public class LongOperation extends AsyncTask<String, Void, String> {


        @RequiresApi(api = Build.VERSION_CODES.N)
        @Override
        protected String doInBackground(String... params) {

            socket = null;
            SocketAddress address = new InetSocketAddress(server_address, server_port);

            socket = new Socket();


            try {
                socket.connect(address, 3000);
            } catch (IOException e) {
                Log.d("time", "no worky X");
                e.printStackTrace();

            }
            try {
                socket.setSoTimeout(3000);
            } catch (SocketException e) {
                Log.d("timeout", "server took too long to respond");

                e.printStackTrace();
                return "Can't Connect";
            }
            OutputStream out = null;
            try {
                out = socket.getOutputStream();
            } catch (IOException e) {
                e.printStackTrace();
            }
            PrintWriter output = new PrintWriter(out);


            output.print(msg);
            //output.flush();

//read
            String str = "waiting";
            BufferedReader br = null;
            try {
                br = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            } catch (IOException e) {
                e.printStackTrace();
            }
            try {
                Log.d("test", "trying to read from server");

                String line;
                str = "";
                while ((line = br.readLine()) != null) {
                    Log.d("read line", line);
                    str = str + line;
                    str = str + "\r\n";
                }
            } catch (IOException e) {
                e.printStackTrace();
            }
            if (str != null) {
                Log.d("test", "trying to print what was just read");
                System.out.println(str);
            }


//read
            output.close();

//read
            try {
                br.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
//read
            try {
                socket.close();
            } catch (IOException e) {
                e.printStackTrace();
            }

            Log.d("tag", "done server");
            return str;
        }

        @Override
        protected void onPostExecute(String result) {

            // might want to change "executed" for the returned string passed
            // into onPostExecute() but that is upto you
            Abort = false;
            Log.d("Set Abort", Abort.toString());
            Log.d("tag", "post ex");
            resp = result;

        }

        @Override
        protected void onPreExecute() {
        }

        @Override
        protected void onProgressUpdate(Void... values) {
        }


        protected void onCancelled() {
            Log.d("cancel", "ca");
            try {
                socket.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
            Abort = false;
        }

    }
    //Метод отправки данных на сервер
    public void sendMessage() {
        if (Abort == true) {
            lo.cancel(false);
            Log.d("Aborting", Abort.toString());
        } else {
            lo = new LongOperation();
            lo.execute();
        }
        Abort = true;
    }

}



