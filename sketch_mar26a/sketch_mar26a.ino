const int B1_PIN = 12;       
const int B2_PIN = 13;
const int G_PIN = 6;
const int Y_PIN = 7;
const int R_PIN = 5;

void setup() {
  Serial.begin(9600);
  pinMode(B1_PIN, INPUT_PULLUP);
  pinMode(B2_PIN, INPUT_PULLUP);
  pinMode(G_PIN, OUTPUT);
  pinMode(Y_PIN, OUTPUT);
  pinMode(R_PIN, OUTPUT);
  
}

void loop() {
  
  int reset=0;
  digitalWrite(G_PIN, LOW);
  digitalWrite(R_PIN, LOW);
  digitalWrite(Y_PIN, LOW);
  
  int B1_state;
  int B2_state;
  
  while(reset <= 1)
  {   
    do{
      B1_state = digitalRead(B1_PIN);
      B2_state = digitalRead(B2_PIN);
    }
    while(B1_state == HIGH && B2_state == HIGH);
    
    if(B1_state==LOW && B2_state==HIGH){
      reset=reset+1;
      digitalWrite(G_PIN, HIGH);
      delay(600);    
    } 
    if(B1_state==HIGH && B2_state==LOW){
      digitalWrite(R_PIN, HIGH);
      digitalWrite(Y_PIN, HIGH);
      delay(600);
    }
  }
  
}
