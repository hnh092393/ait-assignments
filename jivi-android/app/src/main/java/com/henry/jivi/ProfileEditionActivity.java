package com.henry.jivi;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;

import androidx.appcompat.app.AppCompatActivity;

import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;

import java.util.HashMap;

public class ProfileEditionActivity extends AppCompatActivity {

    private ImageButton imageButtonMenu;
    private Button buttonSave;
    private Button buttonCancel;
    private EditText editTextEmail;
    private EditText editTextAddress;

    private EditText editTextPhoneNumber;
    private EditText editTextFacebook;

    FirebaseUser mFirebaseUser;
    FirebaseAuth mFirebaseAuth;
    FirebaseDatabase mFirebaseDatabase;
    DatabaseReference mDatabaseReference;




    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile_edition);

        imageButtonMenu = findViewById(R.id.imageButtonMenu);
        buttonSave = findViewById(R.id.buttonSave);
        buttonCancel = findViewById(R.id.buttonCancel);
        editTextEmail = findViewById(R.id.editTextEmail);
        editTextAddress = findViewById(R.id.editTextAddress);
        editTextPhoneNumber = findViewById(R.id.editTextPhoneNumber);
        editTextFacebook = findViewById(R.id.editTextFacebook);

        mFirebaseAuth = FirebaseAuth.getInstance();
        mFirebaseUser = mFirebaseAuth.getCurrentUser();
        mFirebaseDatabase = FirebaseDatabase.getInstance();
        mDatabaseReference = mFirebaseDatabase.getReference("Users");

        buttonCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(getApplicationContext(), ProfileActivity.class));
            }
        });

        buttonSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String email = mFirebaseUser.getEmail();
                String uID = mFirebaseUser.getUid();

                HashMap<Object, String> hashMap = new HashMap<>();

                hashMap.put("email", email);
                hashMap.put("uID", uID);
                hashMap.put("phoneNumber", "");
                hashMap.put("fullName", "");
                hashMap.put("address", "");
                hashMap.put("facebook", "");
                hashMap.put("birthDay", "");

                mDatabaseReference.child(uID).setValue(hashMap);

                startActivity(new Intent(getApplicationContext(), ProfileActivity.class));
                finish();
            }
        });
    }
}
