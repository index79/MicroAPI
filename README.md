
마이크로 API로 구성해봤습니다. 대부분의 query 는 모두 stored procedure로 작성하여습니다.

stored procedure를 사용함으로써 데이터베이스의 보안을 향상시키고 코드의 요청부분을 분리하여

유지보수를 향상 시켰습니다. 


데이터 보안을 향상시켰다는 말은 이 요청을 사용하는 subscriber가 데이터베이스에 지정된 쿼리만

요청하게 됨으로써 보안에 도움이 된다는 뜻입니다. 쿼리를 따로 분리하는 이유는 유지보수에 큰 

도움을 주기 때문입니다. deploy를 하고 쿼리를 수정하게 되면 다시 컴파일 과정이 필요하지만 

stored procedure를 사용하면 그 부분만 따로 쉽고 빠르게 수정이 가능하기 때문에 선택하였습니다.


데이터 처리는 비지니스 로직과 저장소 간의 중재자 역할을 하는 Repository Pattern을 사용하였습니다. 

이 패턴은 모듈성, 코드 재상용성을 향상시키고 유지보수를 용이하게 합니다.



