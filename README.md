# IntellipickMonthlyIntern
 
### 프로젝트 체크리스트

1. **횡스크롤 방식의 간단한 전투 구현**
    - [x]  플레이어는 고정되어 있고, 1초마다 몬스터에게 100의 대미지 피해를 줍니다.
    - [x]  몬스터의 체력이 0이 되면 다음 몬스터가 등장합니다.
    - [x]  플레이어는 체력이 없고, 공격만 합니다.
2. **Physics.Overlap 사용 적 감지 및 공격**
    - [x]  Physics.Overlap을 활용하여 몬스터를 감지하고 공격을 처리합니다.
3. **OnTriggerEnter 및 Collider를 통한 몬스터 대미지 인식**
    - [x]  몬스터가 Collider를 통해 대미지를 받을 수 있도록 구현합니다.
4. **몬스터 CSV 데이터 파싱**
    - [x]  CSV 파일에서 몬스터 데이터를 파싱하여 Name, Grade, Speed, Health 정보를 불러옵니다.
5. **몬스터 Healthbar 구현 및 이동속도 반영**
    - [x]  몬스터의 체력바를 구현합니다.
    - [x]  CSV에서 불러온 Speed 값을 반영하여 몬스터 이동 속도를 조정합니다.
6. **데이터 순서대로 반복해서 몬스터 등장**
    - [x]  CSV 파일에 입력된 순서대로 몬스터가 차례로 등장하도록 설정합니다.
7. **몬스터 선택 시 팝업창을 띄워 정보 표시**
    - [x]  특정 몬스터를 클릭하면 팝업창이 나타나 몬스터의 정보를 표시하도록 구현합니다.
8. **Firebase를 활용한 서버 연결** (선택사항)
    - [ ]  Firebase 서버를 연결하여 추가적인 서버 연동 기능을 구현합니다.
