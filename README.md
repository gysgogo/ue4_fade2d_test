In Ue4 I can't use fade_2d.getTrianglePointers.


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

I use above code in ue4 beginplay method,when I clicked play button dt.getTrianglePointers(vTriangles) crash my app some times (not every time) .the beginplay method raised error when closed method.error is about free memory.
I have post minimal ue4 project on github that only have one actor Source\ue4_fade2d_test\TestActor.cpp and beginplay is above simple code.
https://github.com/gysgogo/ue4_fade2d_test   Project please use win64 ,click play button multi time ,the error  will happen(not every time)

Exception thrown at 0x00007FFED060DE03 (UE4Editor-Core.dll) in UE4Editor.exe: 0xC0000005: Access violation writing location 0x0000000000000010.
[Inline Frame] UE4Editor-Core.dll!__TBB_machine_cmpswp1(volatile void *) Line 65	C++
[Inline Frame] UE4Editor-Core.dll!__TBB_TryLockByte(unsigned char &) Line 914	C++
[Inline Frame] UE4Editor-Core.dll!__TBB_LockByte(unsigned char &) Line 921	C++
[Inline Frame] UE4Editor-Core.dll!MallocMutex::scoped_lock::{ctor}(MallocMutex &) Line 39	C++
[Inline Frame] UE4Editor-Core.dll!rml::internal::Bin::addPublicFreeListBlock(rml::internal::Block *) Line 1283	C++
[Inline Frame] UE4Editor-Core.dll!rml::internal::Block::freePublicObject(rml::internal::FreeObject *) Line 1420	C++
UE4Editor-Core.dll!rml::internal::freeSmallObject(void * object) Line 2522	C++
[Inline Frame] UE4Editor-Core.dll!rml::internal::internalPoolFree(rml::internal::MemoryPool * memPool, void *) Line 2621	C++
[Inline Frame] UE4Editor-Core.dll!rml::internal::internalFree(void *) Line 2644	C++
UE4Editor-Core.dll!scalable_free(void * object) Line 2933	C++
UE4Editor-Core.dll!FMemory::Free(void * Original) Line 80 C++

