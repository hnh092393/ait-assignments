package com.henry.jivi;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.database.ChildEventListener;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.Query;

public class ProfileActivity extends AppCompatActivity {

    private TextView textViewEdit;
    private ImageButton imageButtonUser;
    private ImageButton imageButtonMenu;
    private User user;

    // objects for connecting to Firebase
    private FirebaseAuth mFirebaseAuth;
    private FirebaseUser mfirebaseUser;
    private FirebaseDatabase mFirebaseDatabase;
    private DatabaseReference mUsersDatabaseReference;
    private ChildEventListener mChildEventListener;
    private FirebaseAuth.AuthStateListener mAuthStateListener;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile);

        textViewEdit = findViewById(R.id.textViewEdit);
        imageButtonUser = findViewById(R.id.imageButtonUser);
        imageButtonMenu = findViewById(R.id.imageButtonMenu);


        // instances of Firebase objects
        mFirebaseDatabase = FirebaseDatabase.getInstance();
        mUsersDatabaseReference = mFirebaseDatabase.getReference().child("users");
        mFirebaseAuth = FirebaseAuth.getInstance();
        mfirebaseUser = mFirebaseAuth.getCurrentUser();

        Query query = mUsersDatabaseReference.orderByChild("email").equalTo(mfirebaseUser.getEmail());
//        query.addChildEventListener(new ValueEventListener() {
//            @Override
//            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
//                for (DataSnapshot ds : dataSnapshot.getChildren()) {
//                    String fullName = "" + ds.child("fullName").getValue();
//                    String email = "" + ds.child("email").getValue();
//
//                    String birthDay = "" + ds.child("birthDay").getValue();
//
//                    String address = "" + ds.child("address").getValue();
//                    String phoneNumber = "" + ds.child("phoneNumber").getValue();
//                    String facebook = "" + ds.child("facebook").getValue();
//
//                }
//            }
//
//            @Override
//            public void onCancelled(@NonNull DatabaseError databaseError) {
//
//            }
//        }






        imageButtonUser.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent  = new Intent(getApplicationContext(), ProfileEditionActivity.class);
                startActivity(intent);
            }
        });

        textViewEdit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent  = new Intent(getApplicationContext(), ProfileEditionActivity.class);
                startActivity(intent);
            }
        });

        imageButtonMenu.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent  = new Intent(getApplicationContext(), MenuActivity.class);
                startActivity(intent);
            }
        });


    }
}
