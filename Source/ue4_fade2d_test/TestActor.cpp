// Fill out your copyright notice in the Description page of Project Settings.


#include "TestActor.h"
#include "Fade_2D.h"
using namespace GEOM_FADE2D;
// Sets default values
ATestActor::ATestActor()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void ATestActor::BeginPlay()
{
	Super::BeginPlay();
	Fade_2D dt;
	
	Point2 p0(0.0, 0.0);
	Point2 p1(1.0, 0.0);
	Point2 p2(0.5, 2.0);
	Point2 p3(0.5, 0.5);

	// Insert the points
	dt.insert(p0);
	dt.insert(p1);
	dt.insert(p2);
	dt.insert(p3);
	std::vector<Triangle2*> vTriangles;
	dt.getTrianglePointers(vTriangles);
	
}

// Called every frame
void ATestActor::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

