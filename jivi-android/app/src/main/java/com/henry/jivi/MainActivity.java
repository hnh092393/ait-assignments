package com.henry.jivi;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import com.google.android.gms.auth.api.signin.GoogleSignIn;
import com.google.android.gms.auth.api.signin.GoogleSignInAccount;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;

public class MainActivity extends AppCompatActivity {

    private ImageButton imageButtonUser;
    private ImageButton imageButtonMenu;
    private TextView textViewLogIn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        imageButtonMenu = findViewById(R.id.imageButtonMenu);
        imageButtonUser = findViewById(R.id.imageButtonUser);
        textViewLogIn = findViewById(R.id.textViewEdit);

        imageButtonUser.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent  = new Intent(getApplicationContext(), SupportActivity.class);
                startActivity(intent);
            }
        });

        textViewLogIn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent  = new Intent(getApplicationContext(), SupportActivity.class);
                startActivity(intent);
            }
        });


    }

    @Override
    public void onStart() {
        super.onStart();

        // Check for existing Google Sign In account, if the user is already signed in
        // the GoogleSignInAccount will be non-null.
        GoogleSignInAccount account = GoogleSignIn.getLastSignedInAccount(this);
        // updateUI(account);

        FirebaseUser currentUser = FirebaseAuth.getInstance().getCurrentUser();
        //updateUI(currentUser);

        if(currentUser != null) {
            startActivity(new Intent(getApplicationContext(), SupportActivity.class));
        }

    }



}
